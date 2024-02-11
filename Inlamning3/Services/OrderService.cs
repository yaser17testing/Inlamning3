using Inlamning3.Entites;
using Inlamning3.Repository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning3.Services;

internal class OrderService
{


    private readonly OrderRepository _orderRepository;

    public OrderService(OrderRepository orderRepository)
    {
        _orderRepository = orderRepository;





    }




    public OrderEntity CreateRole(string orderName)
    {

        var orderEntity = _orderRepository.GetOne(x => x.OrderDetails == orderName);
        orderEntity ??= _orderRepository.Create(new OrderEntity { OrderDetails = orderName });

        return orderEntity;


        



    }



    public OrderEntity GetOrderByName(string orderName)
    {

        var orderGet = _orderRepository.GetOne(x => x.OrderDetails == orderName);

        if (orderGet != null)
        {

            return orderGet;


        }
        else
        {


            return null!;

        }


    }


    public OrderEntity GetOrderById(int id)
    {

        var orderGet = _orderRepository.GetOne(x => x.OrderID == id);

        if (orderGet != null)
        {

            return orderGet;


        }
        else
        {


            return null!;

        }




    }



    public IEnumerable<OrderEntity> GetAllRoles()
    {

        var allOrders = _orderRepository.GetAll();


        return allOrders;



    }




    public OrderEntity updateOrder(OrderEntity OrderName)
    {

        try
        {


            var existingOrder = _orderRepository.GetOne(x => x.OrderID == OrderName.OrderID);



            if (existingOrder != null)
            {




                existingOrder.OrderID = OrderName.OrderID;











                var updatedOrder = _orderRepository.Update(existingOrder);

                if (updatedOrder != null)
                {
                    return updatedOrder;
                }


            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }
        return null!;
    }











    public bool DeleteOrder(OrderEntity OrderName)
    {


        try
        {


            if (_orderRepository.Exists(x => x.OrderID == OrderName.OrderID))
            {
                var deleteOrder = _orderRepository.Delete(x => x.OrderID == OrderName.OrderID);






                return deleteOrder;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }

        return false;


    }























}

