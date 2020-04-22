using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalRTest
{
    internal class Program
    {
        public static HubConnection _hubConnection { get; set; }

        private static void Main(string[] args)
        {
            InitChatHub().Wait();
            Console.WriteLine("Connected!");
            Console.WriteLine("Press enter to test");
            Console.ReadLine();
            TestMessage().Wait();
        }

        private static async Task InitChatHub()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl($"https://localhost:5011/ChatHub")
                .Build();

            await _hubConnection.StartAsync();

            _hubConnection.On<string>("CreateRoom",
                (room) => { Console.WriteLine($"{room}"); });

            _hubConnection.On<string>("Send",
                (message) => { Console.WriteLine($"{message}"); });

            _hubConnection.On<string>("SendMessageToGroup",
                (message) => { Console.WriteLine($"{message}"); });
        }

        private static async Task TestMessage()
        {
            await _hubConnection.SendAsync("CreateRoom", "TestRoom");
            Console.ReadLine();
            var message = new Message() {Content = "TestMessage", Username = "TestUser"};
            await _hubConnection.SendAsync("SendMessageToGroup", message, "TestRoom");
            Console.ReadLine();
        }


        //private static async Task InitResourceHub()
        //{
        //    //_hubConnection = new HubConnectionBuilder()
        //    //    .WithUrl($"http://81.27.216.103/SignalR/ResourceHub")
        //    //    .Build();

        //    _hubConnection = new HubConnectionBuilder()
        //        .WithUrl($"https://localhost:5007/ResourceHub")
        //        .Build();

        //    await _hubConnection.StartAsync();

        //    _hubConnection.On<Resource>("UpdateResource",
        //        (resource) => { Console.WriteLine($"Update: {resource.Name}"); });

        //    _hubConnection.On<Resource>("CreateResource",
        //        (resource) => { Console.WriteLine($"Create: {resource.Name}"); });

        //    _hubConnection.On<Resource>("DeleteResource",
        //        (resource) => { Console.WriteLine($"Delete: {resource.Name}"); });
        //}

        //private static async Task TestResource()
        //{
        //    var resource = new Resource() {Id = Guid.NewGuid(), Name = "SignalR"};
        //    await _hubConnection.SendAsync("CreateResource", resource);
        //    Console.ReadLine();
        //    resource.Name = "Edited";
        //    await _hubConnection.SendAsync("UpdateResource", resource);
        //    Console.ReadLine();
        //    await _hubConnection.SendAsync("DeleteResource", resource);
        //}


        //private static async Task InitReservationHub()
        //{
        //    //_hubConnection = new HubConnectionBuilder()
        //    //    .WithUrl($"http://81.27.216.103/SignalR/ReservationHub")
        //    //    .Build();

        //    _hubConnection = new HubConnectionBuilder()
        //        .WithUrl($"https://localhost:5007/ReservationHub")
        //        .Build();

        //    await _hubConnection.StartAsync();

        //    _hubConnection.On<Reservation>("UpdateReservation",
        //        (reservation) => { Console.WriteLine($"Update: {reservation.Id}"); });

        //    _hubConnection.On<Reservation>("CreateReservation",
        //        (reservation) => { Console.WriteLine($"Create: {reservation.Id}"); });

        //    _hubConnection.On<Reservation>("DeleteReservation",
        //        (reservation) => { Console.WriteLine($"Delete: {reservation.Id}"); });
        //}

        //private static async Task TestReservation()
        //{
        //    var reservation = new Reservation()
        //    {
        //        Id = Guid.NewGuid(),
        //        ResourceId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
        //        UserId = Guid.NewGuid(),
        //        Timeslot = new ReserveTime()
        //        {
        //            ReservationId = Guid.NewGuid(),
        //            FromDate = DateTime.Now.AddHours(1),
        //            ToDate = DateTime.Now.AddHours(2)
        //        }
        //    };
        //    await _hubConnection.SendAsync("CreateReservation", reservation);
        //    Console.ReadLine();
        //    reservation.Timeslot.ToDate = DateTime.Now.AddHours(4);
        //    await _hubConnection.SendAsync("UpdateReservation", reservation);
        //    Console.ReadLine();
        //    await _hubConnection.SendAsync("DeleteReservation", reservation);

        //    Console.ReadLine();
        //    //InitResourceHub();
        //    //var resource = new Resource()
        //    //{
        //    //    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
        //    //    Name = "Testing",
        //    //    TimeSlots = new System.Collections.Generic.List<AvailableTime>()
        //    //    {
        //    //        new AvailableTime()
        //    //        {
        //    //            Id = Guid.NewGuid(), Available = true, From = DateTime.Now.AddHours(1),
        //    //            To = DateTime.Now.AddHours(2), ResourceId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")
        //    //        }
        //    //    }
        //    //};
        //    //await _hubConnection.SendAsync("UpdateResource", resource);

        //    //Console.ReadLine();
        //    //resource = new Resource()
        //    //{
        //    //    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
        //    //    Name = "Testing",
        //    //    TimeSlots = new System.Collections.Generic.List<AvailableTime>()
        //    //    {
        //    //        new AvailableTime()
        //    //        {
        //    //            Id = Guid.NewGuid(), Available = true, From = DateTime.Now.AddHours(1),
        //    //            To = DateTime.Now.AddHours(4), ResourceId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")
        //    //        }
        //    //    }
        //    //};
        //    //await _hubConnection.SendAsync("UpdateResource", resource);

        //    //Console.ReadLine();
        //    //resource = new Resource()
        //    //{ Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), Name = "Testing", TimeSlots = null };
        //    //await _hubConnection.SendAsync("UpdateResource", resource);
        //}
    }
}