using ShopApplication.Converters;
using ShopApplication.Models;
using ShopApplication.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ShopApplication.ViewModels
{
    public class MakeProductViewModel : ErrorViewModelBase, INotifyDataErrorInfo
    {
        public MakeProductViewModel(DataAdapterClient dataAdapterClient,Product p)
        {
			Id = p.Id;
			ModelNumber = p.ModelNumber;
			CategoryId = p.CategoryId;
			ModelName = p.ModelName;
			Cost = p.Cost;
			Description = p.Description;
            DataAdapterClient = dataAdapterClient;
			LoadCategories();
        }
        public MakeProductViewModel(DataAdapterClient dataAdapterClient,int Count)
        {
			Id = Count;
            DataAdapterClient = dataAdapterClient;
            LoadCategories();
        }
		
        private void LoadCategories()
        {
			DataAdapterClient.Categories().ContinueWith((task) => 
			{
				Categories = task.Result;
                Category = Categories.FirstOrDefault(c => c.Id == CategoryId);

                OnPropertyChanged(nameof(Categories));
				
			});
        }
        #region Properties
        private int id;
		public int Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
				OnPropertyChanged(nameof(Id));
			}
		}
		public int? CategoryId { get; set; }
		private Category? category;
		public Category? Category
		{
			get
			{
				return category;
			}
			set
			{
				category = value;
				OnPropertyChanged(nameof(Category));
			}
		}

		private int? modelNumber;
		public int? ModelNumber
		{
			get
			{
				return modelNumber;
			}
			set
			{
                modelNumber = value;
				OnPropertyChanged(nameof(ModelNumber));
			}
		}

		private string? modelName;
		public string? ModelName
		{
			get
			{
				return modelName;
			}
			set
			{
				modelName = value;
				OnPropertyChanged(nameof(ModelName));
			}
		}

		private decimal? cost;
		public decimal? Cost
		{
			get
			{
				return cost;
			}
			set
			{
				cost = value;
				OnPropertyChanged(nameof(Cost));
			}
		}

		private string? description;


        public string? Description
		{
			get
			{
				return description;
			}
			set
			{
				description = value;
				OnPropertyChanged(nameof(Description));
			}
		}

        public DataAdapterClient DataAdapterClient { get; }

        public IEnumerable<Category> Categories { get; set; }

        #endregion

    }
}
