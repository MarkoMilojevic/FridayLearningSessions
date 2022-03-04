namespace Playground;

public class OrderService
{
    public IOrderRepository OrderRepository { get; }
    public IEventHandler<OrderApproved> OrderApprovedHandler { get; }

    public OrderService(
        IOrderRepository orderRepository,
        IEventHandler<OrderApproved> orderApprovedHandler)
    {
        this.OrderRepository = orderRepository;
        this.OrderApprovedHandler = orderApprovedHandler;
    }

    public void ApproveOrder(Order order)
    {
        order.Approve();

        this.OrderRepository.Save(order);

        this.OrderApprovedHandler.Handle(
            new OrderApproved(order.Id));
    }

    public static void Main()
    {
        OrderApprovedReceiptSender receiptNotification =
            new OrderApprovedReceiptSender(new FtpsMessageService());

        AccountintNotifier accountNotification =
            new AccountintNotifier(
                new CryptoBillingSystem());

        OrderFulfillment orderFulfillmentNotification =
            new OrderFulfillment(
                new NearestLocationService(),
                new InventoryManagement());

        CompositeNotificationService<OrderApproved> notificationService =
            new CompositeNotificationService<OrderApproved>(
                new List<IEventHandler<OrderApproved>>
                {
                receiptNotification,
                accountNotification,
                orderFulfillmentNotification
                });

        OrderService orderService =
            new OrderService(
                new SqlOrderRepository(),
                notificationService);
    }
}

public class CompositeNotificationService<TEvent> : IEventHandler<TEvent>
{
    public IReadOnlyList<IEventHandler<TEvent>> OrderApprovedHandlers { get; }

    public CompositeNotificationService(
        IEnumerable<IEventHandler<TEvent>> orderApprovedHandlers)
    {
        this.OrderApprovedHandlers = orderApprovedHandlers.ToList();
    }

    public void Handle(TEvent orderApproved)
    {
        foreach (IEventHandler<TEvent> orderApprovedHandler in this.OrderApprovedHandlers)
        {
            orderApprovedHandler.Handle(orderApproved);
        }
    }
}

public class OrderApprovedReceiptSender : IEventHandler<OrderApproved>
{
    public IMessageService MessageService { get; }

    public OrderApprovedReceiptSender(
        IMessageService messageService)
    {
        this.MessageService = messageService;
    }

    public void Handle(OrderApproved e)
    {
        this.MessageService.SendReceipt(new OrderReceipt());
    }
}

public class AccountintNotifier : IEventHandler<OrderApproved>
{
    public IBillingSystem BillingSystem { get; }

    public AccountintNotifier(
        IBillingSystem billingSystem)
    {
        this.BillingSystem = billingSystem;
    }

    public void Handle(OrderApproved e)
    {
        this.BillingSystem.NotifyAccounting();
    }
}

public class OrderApproved
{
    public Guid OrderId { get; }

    public OrderApproved(Guid orderId)
    {
        this.OrderId = orderId;
    }
}

public class OrderCancelled
{
    public Guid OrderId { get; }

    public OrderCancelled(Guid orderId)
    {
        this.OrderId = orderId;
    }
}

public interface IEventHandler<TEvent>
{
    void Handle(TEvent e);
}

public class OrderFulfillment : IEventHandler<OrderApproved>
{
    public ILocationService LocationService { get; }
    public IInventoryManagement InventoryManagement { get; }

    public OrderFulfillment(
        ILocationService locationService,
        IInventoryManagement inventoryManagement)
    {
        this.LocationService = locationService;
        this.InventoryManagement = inventoryManagement;
    }

    public void Handle(OrderApproved e)
    {
        Warehouse warehouse = this.LocationService.FindWarehouse();
        this.InventoryManagement.Notify(warehouse);
    }
}

public class Warehouse
{
}

public class OrderReceipt
{
}

public class Order
{
    public Guid Id { get; set; }

    public void Approve()
    {
    }
}

public interface IInventoryManagement
{
    void Notify(Warehouse warehouse);
}

public interface ILocationService
{
    Warehouse FindWarehouse();
}

public interface IBillingSystem
{
    void NotifyAccounting();
}

public interface IMessageService
{
    void SendReceipt(OrderReceipt orderReceipt);
}

public interface IOrderRepository
{
    void Save(Order order);
}

public class SqlOrderRepository : IOrderRepository
{
    public void Save(Order order)
    {
    }
}

public class FtpsMessageService : IMessageService
{
    public void SendReceipt(OrderReceipt orderReceipt)
    {
    }
}

public class CryptoBillingSystem : IBillingSystem
{
    public void NotifyAccounting()
    {
    }
}

public class NearestLocationService : ILocationService
{
    public Warehouse FindWarehouse()
    {
        return new Warehouse();
    }
}

public class InventoryManagement : IInventoryManagement
{
    public void Notify(Warehouse warehouse)
    {
    }
}
