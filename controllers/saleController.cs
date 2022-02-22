using psi.context;
using psi.model;
using Microsoft.EntityFrameworkCore;

public static class saleController {
  public static void MapSaleControllerEndpoints(this WebApplication app) {
    app.MapPost("/sale", saleController.postSale);
  }
  private static async Task<IResult> postSale(
    saleRecord[] saleList,
    inventoryContext inventoryContext,
    saleRecordContext saleRecordContext
  ) {
    foreach (var sale in saleList) {
      saleRecordContext.sale_record.Add(sale);
      var inventory = await inventoryContext.inventories.FindAsync(sale.from_inventory);
      if (inventory is null || inventory.inventory_quantity < sale.sale_quantity) return Results.NotFound();
      inventory.inventory_quantity-=sale.sale_quantity;
    }
    await inventoryContext.SaveChangesAsync();
    await saleRecordContext.SaveChangesAsync();
    return Results.Ok();
  }
}
