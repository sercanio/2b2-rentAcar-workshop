﻿namespace Business.Requests.Transmission
{
    public class DeleteTransmissionRequest
    {
        public int Id { get; set; }
        public DeleteTransmissionRequest(int id)
        {
            Id = id;
        }
    }
}