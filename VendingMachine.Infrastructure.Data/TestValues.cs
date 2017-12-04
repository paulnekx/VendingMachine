using System.Collections.Generic;
using System.Collections.ObjectModel;
using VendingMachine.Domain.Entities.Mappings;

namespace VendingMachine.Infrastructure.Data
{
    public static class TestValues
    {
        public static ReadOnlyCollection<ProductMap> Products = new List<ProductMap>
        {
            new ProductMap { Id = 1,    Name = "Хлеб",          Cost = 10,  MaxAmount = 1 }, //index = 0
            new ProductMap { Id = 2,    Name = "Булочка",       Cost = 15,  MaxAmount = 1 }, //index = 1
            new ProductMap { Id = 3,    Name = "Чипсы",         Cost = 34,  MaxAmount = 1 }, //index = 2
            new ProductMap { Id = 4,    Name = "Печенье",       Cost = 29,  MaxAmount = 1 }, //index = 3
            new ProductMap { Id = 5,    Name = "Ветчина",       Cost = 15,  MaxAmount = 1 }, //index = 4
            new ProductMap { Id = 6,    Name = "Сыр",           Cost = 10,  MaxAmount = 1 }, //index = 5

            new ProductMap { Id = 7,    Name = "Вода",          Cost = 20,  MaxAmount = 1 }, //index = 6
            new ProductMap { Id = 8,    Name = "Эспрессо",      Cost = 50,  MaxAmount = 1 }, //index = 7
            new ProductMap { Id = 9,    Name = "Латте",         Cost = 60,  MaxAmount = 1 }, //index = 8
            new ProductMap { Id = 10,   Name = "Капучино",      Cost = 70,  MaxAmount = 1 }, //index = 9
            new ProductMap { Id = 11,   Name = "Чай черный",    Cost = 25,  MaxAmount = 1 }, //index = 10
            new ProductMap { Id = 12,   Name = "Чай зеленый",   Cost = 25,  MaxAmount = 1 }, //index = 11
            new ProductMap { Id = 13,   Name = "Молоко",        Cost = 10,  MaxAmount = 1 }, //index = 12
            new ProductMap { Id = 14,   Name = "Сахар",         Cost = 3,   MaxAmount = 5 }, //index = 13
        }
        .AsReadOnly();

        public static ReadOnlyCollection<RecipeMap> Reciepts = new List<RecipeMap>
        {
            new RecipeMap { Id = 1,     Product = Products[0],  Ingredient = Products[4],    IsOptional = true },    //хлеб         - ветчина
            new RecipeMap { Id = 2,     Product = Products[0],  Ingredient = Products[5],    IsOptional = true },    //хлеб         - сыр

            new RecipeMap { Id = 3,     Product = Products[1],  Ingredient = Products[4],    IsOptional = true },    //булочка      - ветчина
            new RecipeMap { Id = 4,     Product = Products[1],  Ingredient = Products[5],    IsOptional = true },    //булочка      - сыр


            new RecipeMap { Id = 5,     Product = Products[8],  Ingredient = Products[7],    IsOptional = false },   //латте        - эспрессо
            new RecipeMap { Id = 6,     Product = Products[8],  Ingredient = Products[12],   IsOptional = false },   //латте        - молоко
            new RecipeMap { Id = 7,     Product = Products[8],  Ingredient = Products[12],   IsOptional = true },    //латте        - молоко
            new RecipeMap { Id = 8,     Product = Products[8],  Ingredient = Products[13],   IsOptional = true },    //латте        - сахар

            new RecipeMap { Id = 9,     Product = Products[9],  Ingredient = Products[7],    IsOptional = false },   //капучино     - эспрессо
            new RecipeMap { Id = 10,    Product = Products[9],  Ingredient = Products[12],   IsOptional = false },   //капучино     - молоко
            new RecipeMap { Id = 11,    Product = Products[9],  Ingredient = Products[13],   IsOptional = true },    //капучино     - сахар

            new RecipeMap { Id = 12,    Product = Products[10], Ingredient = Products[12],   IsOptional = true },    //черный чай   - молоко
            new RecipeMap { Id = 13,    Product = Products[10], Ingredient = Products[13],   IsOptional = true },    //черный чай   - сахар

            new RecipeMap { Id = 12,    Product = Products[11], Ingredient = Products[12],   IsOptional = true },    //зеленый чай  - молоко
            new RecipeMap { Id = 13,    Product = Products[11], Ingredient = Products[13],   IsOptional = true },    //зеленый чай  - сахар
            
        }
        .AsReadOnly();
    }
}
