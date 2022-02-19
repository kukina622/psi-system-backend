using psi.context;
using psi.model;
using Microsoft.EntityFrameworkCore;

public static class customerController {
  public static void MapCustomerEndpoints(this WebApplication app) {
    app.MapGet("/customer", customerController.getCustomer);
    app.MapPost("/customer", customerController.postCustomer);
    app.MapPut("/customer/{id:int}", customerController.putCustomer);
    app.MapDelete("/customer/{id:int}", customerController.deleteCustomer);
  }
  private static async Task<List<customer>> getCustomer(customerContext context) {
    return await context.customers.ToListAsync();
  }
  private static async Task<IResult> postCustomer(
    customer customer,
    customerContext context
  ) {
    context.customers.Add(customer);
    await context.SaveChangesAsync();
    return Results.Ok(customer);
  }
  private static async Task<IResult> putCustomer(
      int id,
      customer updateCustomer,
      customerContext context
    ) {
    var customer = await context.customers.FindAsync(id);
    if (customer is null) return Results.NotFound();
    // update entity
    customer.customer_name = updateCustomer.customer_name;
    customer.tax_ID = updateCustomer.tax_ID;
    customer.contact_person = updateCustomer.contact_person;
    customer.phone = updateCustomer.phone;
    customer.fax_number = updateCustomer.fax_number;
    customer.customer_email = updateCustomer.customer_email;
    customer.customer_address = updateCustomer.customer_address;
    await context.SaveChangesAsync();
    return Results.NoContent();
  }
  private static async Task<IResult> deleteCustomer(
    int id,
    customerContext context
  ) {
    var customer = await context.customers.FindAsync(id);
    if (customer is null) return Results.NotFound();
    context.customers.Remove(customer);
    await context.SaveChangesAsync();
    return Results.Ok(customer);
  }
}
