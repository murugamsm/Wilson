﻿using System;

namespace Wilson.Companies.Core.Entities
{
    public class Offer : Entity
    {
        protected Offer()
        {
        }

        public DateTime? SentAt { get; private set; }

        public int Revision { get; private set; }

        public DateTime? LastRevisedAt { get; private set; }

        public string HtmlContent { get; private set; }

        public bool IsApproved{ get; private set; }

        public bool IsSent{ get; private set; }

        public DateTime? ApprovedAt { get; private set; }

        public string InquiryId { get; private set; }

        public string SentById { get; private set; }

        public string CreatedById { get; private set; }

        public string ContractId { get; private set; }

        public virtual Inquiry Inquiry { get; private set; }

        public virtual Employee SentBy { get; private set; }

        public virtual Employee CreatedBy { get; private set; }

        public virtual CompanyContract Contract { get; private set; }

        public static Offer Create(string htmlContent, Inquiry inquiry, Employee createdBy)
        {
            return new Offer()
            {
                HtmlContent = htmlContent,
                IsApproved = false,
                IsSent = false,
                Inquiry = inquiry,
                InquiryId = inquiry.Id
            };
        }

        public void Revise(string htmlContent)
        {
            this.HtmlContent = htmlContent;
            this.Revision++;
            this.LastRevisedAt = DateTime.Now;
        }

        public string Send(Employee sendBy)
        {
            this.IsSent = true;
            this.SentBy = sendBy;
            this.SentById = sendBy.Id;
            this.SentAt = DateTime.Now;

            return this.HtmlContent;
        }

        public void MarckApproved()
        {
            this.IsApproved = true;
            this.ApprovedAt = DateTime.Now;
        }

        public void AddToContract(CompanyContract contract)
        {
            this.Contract = contract;
            this.ContractId = ContractId;
        }
    }
}
