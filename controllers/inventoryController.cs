using psi.context;
using psi.model;
using Microsoft.EntityFrameworkCore;

public static class inventoryController {
  public static void MapInventoryEndpoints(this WebApplication app) {
    app.MapGet("/inventory", inventoryController.getInventory);
    app.MapPost("/inventory", inventoryController.postInventory);
    app.MapPut("/inventory/{id:int}", inventoryController.putInventory);
    app.MapDelete("/inventory/{id:int}", inventoryController.deleteInventory);
  }
  private static async Task<List<inventory>> getInventory(inventoryContext context) {
    return await context.inventories.ToListAsync();
  }
  private static async Task<IResult> postInventory(
    inventory inventory,
    inventoryContext context
  ) {
    context.inventories.Add(inventory);
    await context.SaveChangesAsync();
    return Results.Ok();
  }
  private static async Task<IResult> putInventory(
      int id,
      inventory updateInventory,
      inventoryContext context
    ) {
    var inventory = await context.inventories.FindAsync(id);
    if (inventory is null) return Results.NotFound();
    // update entity
    inventory.inventory_type = updateInventory.inventory_type;
    inventory.inventory_name = updateInventory.inventory_name;
    inventory.purchase_price = updateInventory.purchase_price;
    inventory.inventory_quantity = updateInventory.inventory_quantity;
    inventory.purchase_time = updateInventory.purchase_time;
    await context.SaveChangesAsync();
    return Results.NoContent();
  }
  private static async Task<IResult> deleteInventory(
    int id,
    inventoryContext context
  ) {
    var inventory = await context.inventories.FindAsync(id);
    if (inventory is null) return Results.NotFound();
    context.inventories.Remove(inventory);
    await context.SaveChangesAsync();
    return Results.Ok(inventory);
  }
}
