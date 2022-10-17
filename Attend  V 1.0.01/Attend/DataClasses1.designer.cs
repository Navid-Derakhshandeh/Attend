﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Attend
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Attend")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertInventory(Inventory instance);
    partial void UpdateInventory(Inventory instance);
    partial void DeleteInventory(Inventory instance);
    partial void InsertMRO(MRO instance);
    partial void UpdateMRO(MRO instance);
    partial void DeleteMRO(MRO instance);
    partial void InsertMRE(MRE instance);
    partial void UpdateMRE(MRE instance);
    partial void DeleteMRE(MRE instance);
    partial void InsertMC(MC instance);
    partial void UpdateMC(MC instance);
    partial void DeleteMC(MC instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::Attend.Properties.Settings.Default.AttendConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Inventory> Inventories
		{
			get
			{
				return this.GetTable<Inventory>();
			}
		}
		
		public System.Data.Linq.Table<MRO> MROs
		{
			get
			{
				return this.GetTable<MRO>();
			}
		}
		
		public System.Data.Linq.Table<MRE> MREs
		{
			get
			{
				return this.GetTable<MRE>();
			}
		}
		
		public System.Data.Linq.Table<MC> MCs
		{
			get
			{
				return this.GetTable<MC>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Inventory")]
	public partial class Inventory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.DateTime _Date_Added;
		
		private string _Name;
		
		private string _Manufacture;
		
		private System.Nullable<int> _Quantity;
		
		private System.Nullable<int> _Cost_Price;
		
		private System.Nullable<int> _Sell_Price;
		
		private string _Model_Name;
		
		private string _Loacation;
		
		private string _Condition;
		
		private string _Availabel;
		
		private string _Allocated;
		
		private string _Suppliers;
		
		private string _Category;
		
		private System.Nullable<int> _Serial_Number;
		
		private string _Notes;
		
		private System.Data.Linq.Binary _Image;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnDate_AddedChanging(System.DateTime value);
    partial void OnDate_AddedChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnManufactureChanging(string value);
    partial void OnManufactureChanged();
    partial void OnQuantityChanging(System.Nullable<int> value);
    partial void OnQuantityChanged();
    partial void OnCost_PriceChanging(System.Nullable<int> value);
    partial void OnCost_PriceChanged();
    partial void OnSell_PriceChanging(System.Nullable<int> value);
    partial void OnSell_PriceChanged();
    partial void OnModel_NameChanging(string value);
    partial void OnModel_NameChanged();
    partial void OnLoacationChanging(string value);
    partial void OnLoacationChanged();
    partial void OnConditionChanging(string value);
    partial void OnConditionChanged();
    partial void OnAvailabelChanging(string value);
    partial void OnAvailabelChanged();
    partial void OnAllocatedChanging(string value);
    partial void OnAllocatedChanged();
    partial void OnSuppliersChanging(string value);
    partial void OnSuppliersChanged();
    partial void OnCategoryChanging(string value);
    partial void OnCategoryChanged();
    partial void OnSerial_NumberChanging(System.Nullable<int> value);
    partial void OnSerial_NumberChanged();
    partial void OnNotesChanging(string value);
    partial void OnNotesChanged();
    partial void OnImageChanging(System.Data.Linq.Binary value);
    partial void OnImageChanged();
    #endregion
		
		public Inventory()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date_Added", DbType="DateTime NOT NULL")]
		public System.DateTime Date_Added
		{
			get
			{
				return this._Date_Added;
			}
			set
			{
				if ((this._Date_Added != value))
				{
					this.OnDate_AddedChanging(value);
					this.SendPropertyChanging();
					this._Date_Added = value;
					this.SendPropertyChanged("Date_Added");
					this.OnDate_AddedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(200)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Manufacture", DbType="VarChar(MAX)")]
		public string Manufacture
		{
			get
			{
				return this._Manufacture;
			}
			set
			{
				if ((this._Manufacture != value))
				{
					this.OnManufactureChanging(value);
					this.SendPropertyChanging();
					this._Manufacture = value;
					this.SendPropertyChanged("Manufacture");
					this.OnManufactureChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int")]
		public System.Nullable<int> Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cost_Price", DbType="Int")]
		public System.Nullable<int> Cost_Price
		{
			get
			{
				return this._Cost_Price;
			}
			set
			{
				if ((this._Cost_Price != value))
				{
					this.OnCost_PriceChanging(value);
					this.SendPropertyChanging();
					this._Cost_Price = value;
					this.SendPropertyChanged("Cost_Price");
					this.OnCost_PriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sell_Price", DbType="Int")]
		public System.Nullable<int> Sell_Price
		{
			get
			{
				return this._Sell_Price;
			}
			set
			{
				if ((this._Sell_Price != value))
				{
					this.OnSell_PriceChanging(value);
					this.SendPropertyChanging();
					this._Sell_Price = value;
					this.SendPropertyChanged("Sell_Price");
					this.OnSell_PriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Model_Name", DbType="VarChar(MAX)")]
		public string Model_Name
		{
			get
			{
				return this._Model_Name;
			}
			set
			{
				if ((this._Model_Name != value))
				{
					this.OnModel_NameChanging(value);
					this.SendPropertyChanging();
					this._Model_Name = value;
					this.SendPropertyChanged("Model_Name");
					this.OnModel_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Loacation", DbType="VarChar(MAX)")]
		public string Loacation
		{
			get
			{
				return this._Loacation;
			}
			set
			{
				if ((this._Loacation != value))
				{
					this.OnLoacationChanging(value);
					this.SendPropertyChanging();
					this._Loacation = value;
					this.SendPropertyChanged("Loacation");
					this.OnLoacationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Condition", DbType="VarChar(MAX)")]
		public string Condition
		{
			get
			{
				return this._Condition;
			}
			set
			{
				if ((this._Condition != value))
				{
					this.OnConditionChanging(value);
					this.SendPropertyChanging();
					this._Condition = value;
					this.SendPropertyChanged("Condition");
					this.OnConditionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Availabel", DbType="VarChar(MAX)")]
		public string Availabel
		{
			get
			{
				return this._Availabel;
			}
			set
			{
				if ((this._Availabel != value))
				{
					this.OnAvailabelChanging(value);
					this.SendPropertyChanging();
					this._Availabel = value;
					this.SendPropertyChanged("Availabel");
					this.OnAvailabelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Allocated", DbType="VarChar(MAX)")]
		public string Allocated
		{
			get
			{
				return this._Allocated;
			}
			set
			{
				if ((this._Allocated != value))
				{
					this.OnAllocatedChanging(value);
					this.SendPropertyChanging();
					this._Allocated = value;
					this.SendPropertyChanged("Allocated");
					this.OnAllocatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Suppliers", DbType="VarChar(MAX)")]
		public string Suppliers
		{
			get
			{
				return this._Suppliers;
			}
			set
			{
				if ((this._Suppliers != value))
				{
					this.OnSuppliersChanging(value);
					this.SendPropertyChanging();
					this._Suppliers = value;
					this.SendPropertyChanged("Suppliers");
					this.OnSuppliersChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="VarChar(MAX)")]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this.OnCategoryChanging(value);
					this.SendPropertyChanging();
					this._Category = value;
					this.SendPropertyChanged("Category");
					this.OnCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Serial_Number", DbType="Int")]
		public System.Nullable<int> Serial_Number
		{
			get
			{
				return this._Serial_Number;
			}
			set
			{
				if ((this._Serial_Number != value))
				{
					this.OnSerial_NumberChanging(value);
					this.SendPropertyChanging();
					this._Serial_Number = value;
					this.SendPropertyChanged("Serial_Number");
					this.OnSerial_NumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Notes", DbType="VarChar(MAX)")]
		public string Notes
		{
			get
			{
				return this._Notes;
			}
			set
			{
				if ((this._Notes != value))
				{
					this.OnNotesChanging(value);
					this.SendPropertyChanging();
					this._Notes = value;
					this.SendPropertyChanged("Notes");
					this.OnNotesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if ((this._Image != value))
				{
					this.OnImageChanging(value);
					this.SendPropertyChanging();
					this._Image = value;
					this.SendPropertyChanged("Image");
					this.OnImageChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MRO")]
	public partial class MRO : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _Room_Number;
		
		private string _Room_Type;
		
		private int _Phone;
		
		private string _Condition;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnRoom_NumberChanging(int value);
    partial void OnRoom_NumberChanged();
    partial void OnRoom_TypeChanging(string value);
    partial void OnRoom_TypeChanged();
    partial void OnPhoneChanging(int value);
    partial void OnPhoneChanged();
    partial void OnConditionChanging(string value);
    partial void OnConditionChanged();
    #endregion
		
		public MRO()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Room_Number", DbType="Int NOT NULL")]
		public int Room_Number
		{
			get
			{
				return this._Room_Number;
			}
			set
			{
				if ((this._Room_Number != value))
				{
					this.OnRoom_NumberChanging(value);
					this.SendPropertyChanging();
					this._Room_Number = value;
					this.SendPropertyChanged("Room_Number");
					this.OnRoom_NumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Room_Type", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Room_Type
		{
			get
			{
				return this._Room_Type;
			}
			set
			{
				if ((this._Room_Type != value))
				{
					this.OnRoom_TypeChanging(value);
					this.SendPropertyChanging();
					this._Room_Type = value;
					this.SendPropertyChanged("Room_Type");
					this.OnRoom_TypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="Int NOT NULL")]
		public int Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Condition", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Condition
		{
			get
			{
				return this._Condition;
			}
			set
			{
				if ((this._Condition != value))
				{
					this.OnConditionChanging(value);
					this.SendPropertyChanging();
					this._Condition = value;
					this.SendPropertyChanged("Condition");
					this.OnConditionChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MRE")]
	public partial class MRE : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _Reserv_ID;
		
		private int _Client_ID;
		
		private string _Room_T;
		
		private int _Room_N;
		
		private System.DateTime _Date_IN;
		
		private System.DateTime _Date_OUT;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnReserv_IDChanging(int value);
    partial void OnReserv_IDChanged();
    partial void OnClient_IDChanging(int value);
    partial void OnClient_IDChanged();
    partial void OnRoom_TChanging(string value);
    partial void OnRoom_TChanged();
    partial void OnRoom_NChanging(int value);
    partial void OnRoom_NChanged();
    partial void OnDate_INChanging(System.DateTime value);
    partial void OnDate_INChanged();
    partial void OnDate_OUTChanging(System.DateTime value);
    partial void OnDate_OUTChanged();
    #endregion
		
		public MRE()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reserv_ID", DbType="Int NOT NULL")]
		public int Reserv_ID
		{
			get
			{
				return this._Reserv_ID;
			}
			set
			{
				if ((this._Reserv_ID != value))
				{
					this.OnReserv_IDChanging(value);
					this.SendPropertyChanging();
					this._Reserv_ID = value;
					this.SendPropertyChanged("Reserv_ID");
					this.OnReserv_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Client_ID", DbType="Int NOT NULL")]
		public int Client_ID
		{
			get
			{
				return this._Client_ID;
			}
			set
			{
				if ((this._Client_ID != value))
				{
					this.OnClient_IDChanging(value);
					this.SendPropertyChanging();
					this._Client_ID = value;
					this.SendPropertyChanged("Client_ID");
					this.OnClient_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Room_T", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Room_T
		{
			get
			{
				return this._Room_T;
			}
			set
			{
				if ((this._Room_T != value))
				{
					this.OnRoom_TChanging(value);
					this.SendPropertyChanging();
					this._Room_T = value;
					this.SendPropertyChanged("Room_T");
					this.OnRoom_TChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Room_N", DbType="Int NOT NULL")]
		public int Room_N
		{
			get
			{
				return this._Room_N;
			}
			set
			{
				if ((this._Room_N != value))
				{
					this.OnRoom_NChanging(value);
					this.SendPropertyChanging();
					this._Room_N = value;
					this.SendPropertyChanged("Room_N");
					this.OnRoom_NChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date_IN", DbType="DateTime NOT NULL")]
		public System.DateTime Date_IN
		{
			get
			{
				return this._Date_IN;
			}
			set
			{
				if ((this._Date_IN != value))
				{
					this.OnDate_INChanging(value);
					this.SendPropertyChanging();
					this._Date_IN = value;
					this.SendPropertyChanged("Date_IN");
					this.OnDate_INChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date_OUT", DbType="DateTime NOT NULL")]
		public System.DateTime Date_OUT
		{
			get
			{
				return this._Date_OUT;
			}
			set
			{
				if ((this._Date_OUT != value))
				{
					this.OnDate_OUTChanging(value);
					this.SendPropertyChanging();
					this._Date_OUT = value;
					this.SendPropertyChanged("Date_OUT");
					this.OnDate_OUTChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MC")]
	public partial class MC : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _First_Name;
		
		private string _Last_Name;
		
		private int _Phone_C;
		
		private string _Country;
		
		private System.Data.Linq.Binary _Image_C;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnFirst_NameChanging(string value);
    partial void OnFirst_NameChanged();
    partial void OnLast_NameChanging(string value);
    partial void OnLast_NameChanged();
    partial void OnPhone_CChanging(int value);
    partial void OnPhone_CChanged();
    partial void OnCountryChanging(string value);
    partial void OnCountryChanged();
    partial void OnImage_CChanging(System.Data.Linq.Binary value);
    partial void OnImage_CChanged();
    #endregion
		
		public MC()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_First_Name", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string First_Name
		{
			get
			{
				return this._First_Name;
			}
			set
			{
				if ((this._First_Name != value))
				{
					this.OnFirst_NameChanging(value);
					this.SendPropertyChanging();
					this._First_Name = value;
					this.SendPropertyChanged("First_Name");
					this.OnFirst_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Last_Name", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Last_Name
		{
			get
			{
				return this._Last_Name;
			}
			set
			{
				if ((this._Last_Name != value))
				{
					this.OnLast_NameChanging(value);
					this.SendPropertyChanging();
					this._Last_Name = value;
					this.SendPropertyChanged("Last_Name");
					this.OnLast_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone_C", DbType="Int NOT NULL")]
		public int Phone_C
		{
			get
			{
				return this._Phone_C;
			}
			set
			{
				if ((this._Phone_C != value))
				{
					this.OnPhone_CChanging(value);
					this.SendPropertyChanging();
					this._Phone_C = value;
					this.SendPropertyChanged("Phone_C");
					this.OnPhone_CChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Country", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Country
		{
			get
			{
				return this._Country;
			}
			set
			{
				if ((this._Country != value))
				{
					this.OnCountryChanging(value);
					this.SendPropertyChanging();
					this._Country = value;
					this.SendPropertyChanged("Country");
					this.OnCountryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image_C", DbType="VarBinary(MAX) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Image_C
		{
			get
			{
				return this._Image_C;
			}
			set
			{
				if ((this._Image_C != value))
				{
					this.OnImage_CChanging(value);
					this.SendPropertyChanging();
					this._Image_C = value;
					this.SendPropertyChanged("Image_C");
					this.OnImage_CChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591