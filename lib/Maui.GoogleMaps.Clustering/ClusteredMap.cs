﻿using Maui.GoogleMaps.Clustering.Logics;

namespace Maui.GoogleMaps.Clustering
{
    public class ClusteredMap : Map
    {
        public static readonly BindableProperty ClusterOptionsProperty = BindableProperty.Create(nameof(ClusterOptionsProperty),
       typeof(ClusterOptions),
       typeof(Map),
       default(ClusterOptions));
        public static readonly BindableProperty ClusterAlgorithmTypeProperty = BindableProperty.Create(nameof(Type), typeof(ClusterAlgorithm), typeof(ClusteredMap), ClusterAlgorithm.NonHierarchicalDistanceBased);

        public event EventHandler<ClusterClickedEventArgs> ClusterClicked;

        internal Action OnCluster { get; set; }

        internal bool PendingClusterRequest { get; set; }
        public ClusterOptions ClusterOptions
        {
            get => (ClusterOptions)GetValue(ClusterOptionsProperty);
            set => SetValue(ClusterOptionsProperty, value);
        }
        public ClusterAlgorithm ClusterAlgorithmType
        {
            get { return (ClusterAlgorithm)GetValue(ClusterAlgorithmTypeProperty); }
            set { SetValue(ClusterAlgorithmTypeProperty, value); }
        }
        public ClusteredMap()
        {
            ClusterOptions = new ClusterOptions();
        }
        public void Cluster()
        {
            SendCluster();
        }

        private void SendCluster()
        {
            if (OnCluster != null)
            {
                OnCluster.Invoke();
            }
            else
            {
                PendingClusterRequest = true;
            }
        }
        internal void SendClusterClicked(int itemsCount, IEnumerable<Pin> pins, Position position)
            => ClusterClicked?.Invoke(this, new ClusterClickedEventArgs(itemsCount, pins, position));
    }
}
