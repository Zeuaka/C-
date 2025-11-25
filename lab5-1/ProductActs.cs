using System;
using System.Collections.Generic;

public class ProductMovement
{
    public int OperationId { get; set; }
    public DateTime Date { get; set; }
    public int StoreId { get; set; }
    public int Article { get; set; }
    public string OperationType { get; set; }
    public int PackageQuantity { get; set; }
    public string HasCustomerCard { get; set; }

    public ProductMovement(int operationId, DateTime date, int storeId, int article, 
                         string operationType, int packageQuantity, string hasCustomerCard)
    {
        OperationId = operationId;
        Date = date;
        StoreId = storeId;
        Article = article;
        OperationType = operationType;
        PackageQuantity = packageQuantity;
        HasCustomerCard = hasCustomerCard;
    }

    public override string ToString()
    {
        return $"ID операции: {OperationId}, Дата: {Date:dd.MM.yyyy}, Магазин: {StoreId}, " +
               $"Артикул: {Article}, Операция: {OperationType}, " +
               $"Кол-во: {PackageQuantity}, Карта: {HasCustomerCard}";
    }
}

public class Product
{
    public int Article { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
    public int QuantityPerPackage { get; set; }
    public decimal PricePerPackage { get; set; }

    public Product(int article, int categoryId, string name, string unit, 
                  int quantityPerPackage, decimal pricePerPackage)
    {
        Article = article;
        CategoryId = categoryId;
        Name = name;
        Unit = unit;
        QuantityPerPackage = quantityPerPackage;
        PricePerPackage = pricePerPackage;
    }

    public override string ToString()
    {
        return $"Артикул: {Article}, Категория: {CategoryId}, Наименование: {Name}, " +
               $"Ед.изм: {Unit}, В упаковке: {QuantityPerPackage}, Цена: {PricePerPackage:N2} руб.";
    }
}

public class Store
{
    public int Id { get; set; }
    public string District { get; set; }
    public string Address { get; set; }

    public Store(int id, string district, string address)
    {
        Id = id;
        District = district;
        Address = address;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Район: {District}, Адрес: {Address}";
    }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AgeRestriction { get; set; }

    public Category(int id, string name, string ageRestriction)
    {
        Id = id;
        Name = name;
        AgeRestriction = ageRestriction;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Наименование: {Name}, Возраст: {AgeRestriction}";
    }
}