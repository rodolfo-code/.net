using Microsoft.AspNetCore.Mvc;
using CustomerCrud.Core;
using CustomerCrud.Requests;
using CustomerCrud.Repositories;

namespace CustomerCrud.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet]
    public ActionResult<Customer> GetAll()
    {
        var customer = _customerRepository.GetAll();
        return Ok(customer);
    }

    [HttpGet("{ID}", Name = "GetById")]
    public ActionResult GetById(int id)
    {
        var customer = _customerRepository.GetById(id);

        if (customer == null) return CustomerIdNotFound();

        return Ok(customer);
    }

    [HttpPost]
    public ActionResult Create(CustomerRequest request)
    {
        var id = _customerRepository.GetNextIdValue();
        var newCustomer = new Customer(id, request);

        _customerRepository.Create(newCustomer);

        return CreatedAtAction("GetById", new { id = newCustomer.Id }, newCustomer);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, CustomerRequest request)
    {
        var updated = _customerRepository.Update(
            id,
            new
            {
                Name = request.Name,
                CPF = request.CPF,
                Transactions = request.Transactions,
                UpdatedAt = DateTime.Now
            });

        if (!updated) return CustomerIdNotFound();

        return Ok($"Customer {id} updated");
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var deleted = _customerRepository.Delete(id);

        if (!deleted) return CustomerIdNotFound();

        return NoContent();
    }

    private NotFoundObjectResult CustomerIdNotFound()
    {
        return NotFound("Customer not found");
    }

}
