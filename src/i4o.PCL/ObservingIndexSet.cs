﻿using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace IP.i4o
{
	public class ObservingIndexSet<T> : IndexSet<T> where T : INotifyPropertyChanged
	{
		private readonly ObservableCollection<T> _observableCollection;

		private void AttachPropertyChanged(T child)
		{
			child.PropertyChanged += PropertyChanged;
		}

		private void DetachPropertyChanged(T child)
		{
			child.PropertyChanged -= PropertyChanged;
		}

		private void ResetAllChildAttachments()
		{
			DetachAllChildren();
			AttachAllChildren();
		}

		private void DetachAllChildren()
		{
			_observableCollection.ForEach(DetachPropertyChanged);
		}

		private void AttachAllChildren()
		{
			_observableCollection.ForEach(AttachPropertyChanged);
		}

		private void SetupEventHandlers()
		{
			_observableCollection.CollectionChanged += CollectionChanged;
			AttachAllChildren();
		}

		private void PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (IndexSpecification.IndexedProperties.Contains(e.PropertyName) && sender is T)
				IndexDictionary[e.PropertyName].Reset((T)sender);
		}

		private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Reset:
					Reset();
					break;

				case NotifyCollectionChangedAction.Replace:
					RemoveItems(e.OldItems);
					AddItems(e.NewItems);
					break;

				case NotifyCollectionChangedAction.Remove:
					RemoveItems(e.OldItems);
					break;

				case NotifyCollectionChangedAction.Add:
					AddItems(e.NewItems);
					break;

				default:
					break;
			}
		}

		private void RemoveItems(IEnumerable oldItems)
		{
			oldItems.Cast<T>().ForEach(item =>
					{
						DetachPropertyChanged(item);
						IndexDictionary.Values.ToList().ForEach(index =>
								index.Remove(item));
					}
			);
		}

		private void AddItems(IEnumerable oldItems)
		{
			oldItems.Cast<T>().ForEach(item =>
					{
						AttachPropertyChanged(item);
						IndexDictionary.Values.ToList().ForEach(index =>
								index.Add(item));
					}
			);
		}

		private void Reset()
		{
			ResetAllChildAttachments();
			IndexDictionary.Clear();
			SetupIndices(_observableCollection);
		}

		public ObservingIndexSet(ObservableCollection<T> observableCollection, IndexSpecification<T> indexSpecification)
			: base(observableCollection, indexSpecification)
		{
			_observableCollection = observableCollection;
			SetupEventHandlers();
		}
	}
}