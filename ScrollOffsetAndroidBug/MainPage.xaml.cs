using System.Collections.ObjectModel;

namespace ScrollOffsetAndroidBug
{
	public partial class MainPage : ContentPage
	{
		public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(IEnumerable<int>), typeof(MainPage), default(IEnumerable<int>));
		public static readonly BindableProperty VerticalOffsetProperty = BindableProperty.Create(nameof(VerticalOffset), typeof(double), typeof(MainPage), default(double));
		private readonly ObservableCollection<int> _items;

		public IEnumerable<int> Items
		{
			get => (IEnumerable<int>)GetValue(ItemsProperty);
			set => SetValue(ItemsProperty, value);
		}

		public double VerticalOffset
		{
			get => (double)GetValue(VerticalOffsetProperty);
			set => SetValue(VerticalOffsetProperty, value);
		}

		public MainPage()
		{
			InitializeComponent();

			_items = new ObservableCollection<int>();
			Items = new ReadOnlyObservableCollection<int>(_items);

			BindingContext = this;
		}

		private void CollectionView_OnScrolled(object sender, ItemsViewScrolledEventArgs e)
		{
			VerticalOffset = e.VerticalOffset;
		}

		private void EmptyButton_OnClicked(object sender, EventArgs e)
		{
			_items.Clear();
		}

		private void FillButton_OnClicked(object sender, EventArgs e)
		{
			foreach (var i in Enumerable.Range(0, 50))
				_items.Add(i);
		}

	}

}
