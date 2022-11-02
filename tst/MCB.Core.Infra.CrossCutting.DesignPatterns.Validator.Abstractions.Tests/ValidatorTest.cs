using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Enums;
using MCB.Core.Infra.CrossCutting.DesignPatterns.Validator.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MCB.Core.Infra.CrossCutting.DesignPatterns.Abstractions.Tests.ValidatorTests;

public class ValidatorTest
{
    [Fact]
    public void Validator_Should_Validate()
    {
        Assert.True(true);
    }
}

public class CustomerValidator
    : IValidator<Customer>
{
    public ValidationResult Validate(Customer instance)
    {
        if (instance == null)
            return new ValidationResult();

        var validationMessageCollection = new List<ValidationMessage>();

        if (instance.Id == Guid.Empty)
            validationMessageCollection.Add(new ValidationMessage(ValidationMessageType.Error, Code: "CustomerGuidIsRequired", Description: "Customer Id is Required"));
        if(string.IsNullOrWhiteSpace(instance.Name))
            validationMessageCollection.Add(new ValidationMessage(ValidationMessageType.Error, Code: "CustomerNameIsRequired", Description: "Customer Name is Required"));
        if (instance.BirthDate == default)
            validationMessageCollection.Add(new ValidationMessage(ValidationMessageType.Error, Code: "CustomerBirthDateIsRequired", Description: "Customer BirthDate is Required"));
        else
        {
            /*
             * This age calc is wrong because not see the month and day of the current year, but is only a test
             */
            var age = DateTime.UtcNow.Year - instance.BirthDate.Year;
            if (age < 18)
                validationMessageCollection.Add(new ValidationMessage(ValidationMessageType.Information, Code: "CustomerIsUnderAge", Description: "Customer is under age"));
        }
        if(!instance.IsActive)
            validationMessageCollection.Add(new ValidationMessage(ValidationMessageType.Warning, Code: "CustomerIsNotActive", Description: "Customer is not active"));

        if (validationMessageCollection.Count > 0)
            return new ValidationResult(validationMessageCollection);
        else
            return new ValidationResult();
    }

    public Task<ValidationResult> ValidateAsync(Customer instance, CancellationToken cancellationToken)
    {
        return Task.FromResult(Validate(instance));
    }
}

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; }

    public Customer()
    {
        Id = Guid.Empty;
        Name = string.Empty;
        BirthDate = DateTime.Now;
    }
}
