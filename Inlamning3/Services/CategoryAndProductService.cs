using Inlamning3.Entites;
using Inlamning3.Repository;
using Inlamning3.Services.DtoModells;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning3.Services;

internal class CategoryAndProductService(CategoryRepository categoryRepository, ProductRepository productRepository)
{

    private readonly CategoryRepository _categoryRepository = categoryRepository;

    private readonly ProductRepository _productRepository = productRepository;





    public bool CreateProduct(ProductDto product)
    {


        try
        {




            var categoryEntity = _categoryRepository.GetOne(x => x.CategoryName == product.CategoryName);
            categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = product.CategoryName });

            var ProductEntity = new ProductEntity
            {




                Title = product.Title,


                Price = product.Price,

                Description = product.Description,

                CategoryId = categoryEntity.Id


            };

            var result = _productRepository.Create(ProductEntity);
            if (result != null)



                return true;

        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

        return false;


    }


    public ProductEntity GetProductsByTitle(ProductDto product)
    {


        try
        {

            var existing = _productRepository.GetOne(x => x.Title == product.Title);

            if (existing != null)
            {

                Debug.WriteLine($"Product found with Titel: {product.ArtikelID} - {product.Title} - {product.Price} - {product.Description} - {product.CategoryName} ");

                return existing;
            }


            else
            {
                Debug.WriteLine($"No Product found with Titel: {product.Title}");
            }

        }

        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }


        return null!;




    }




    public ProductEntity GetProductsByArtikelID(ProductDto product)
    {


        try
        {

            var existing = _productRepository.GetOne(x => x.ArtikelID == product.ArtikelID);

            if (existing != null)
            {

                Debug.WriteLine($"Product found with Titel: {product.ArtikelID} - {product.Title} - {product.Price} - {product.Description} - {product.CategoryName} ");

                return existing;
            }


            else
            {
                Debug.WriteLine($"No Product found with Titel: {product.ArtikelID}");
            }

        }

        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }


        return null!;




    }








    public IEnumerable<ProductEntity> GetAll()
    {




        try
        {


            var result = _productRepository.GetAll();


            return result;



        }
        catch (Exception ex)
        { Debug.WriteLine("ERROR :: " + ex.Message); }


        return Enumerable.Empty<ProductEntity>();



    }




    public ProductEntity UpdateProduct(ProductEntity product)
    {




        try
        {


           



           


               









                var updatedEntity = _productRepository.Update(x => x.ArtikelID == product.ArtikelID,product);

                if (updatedEntity != null)
                {
                    return updatedEntity;
                }


            
        }
        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }
        return null!;
    }





    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {






        var updatedCategory = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);

        if (updatedCategory != null)
        {

            Console.WriteLine("Suceed");

            return updatedCategory;
        }


        else
        {

            Console.WriteLine("No Category with that Id");

            return null!;
        }

    }
    











    public bool DeleteProduct(ProductDto product)
    {


        try
        {


            if (_productRepository.Exists(x => x.ArtikelID == product.ArtikelID))
            {
                var deleteEntity = _productRepository.Delete(x => x.ArtikelID == product.ArtikelID);






                return deleteEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }

        return false;


    }





    public bool CreateCategory(ProductDto category)
    {

        var categoryEntity = _categoryRepository.GetOne(x => x.CategoryName == category.CategoryName);
        categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = category.CategoryName });

        return true;

    }




    public IEnumerable<CategoryEntity> GetAllCategori()
    {




        try
        {


            var result = _categoryRepository.GetAll();







            return result;



        }
        catch (Exception ex)
        { Debug.WriteLine("ERROR :: " + ex.Message); }


        return Enumerable.Empty<CategoryEntity>();



    }





    public CategoryEntity GetOneCategoriesWithProduct(string fri)
    {


        try
        {

            var existing = _categoryRepository.GetOne(x => x.CategoryName == fri);

            if (existing != null)
            {

                Debug.WriteLine($"Succed: {fri}");

                return existing;
            }


            else
            {
                Debug.WriteLine($"Failed: {fri}");
            }

        }

        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }


        return null!;


    }












    public bool DeleteCategoryById(int category)
    {


        try
        {


            if (_categoryRepository.Exists(x => x.Id == category))
            {
                var deleteEntity = _categoryRepository.Delete(x => x.Id == category);






                return deleteEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }

        return false;


    }







}

