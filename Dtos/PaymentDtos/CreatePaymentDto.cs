﻿namespace IztekTestCase.Dtos.PaymentDtos
{
    public class CreatePaymentDto
    {
        public Guid OrderId { get; set; }
        public decimal PaidAmount { get; set; }
    }
}