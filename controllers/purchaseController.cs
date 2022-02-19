using psi.context;
using psi.model;
using Microsoft.EntityFrameworkCore;

public static class purchaseController {
  public static void MapPurchaseEndpoints(this WebApplication app) {
    app.MapPost("/purchase", purchaseController.postPurchase);
  }
  private static async Task<IResult> postPurchase(
    purchaseRecord[] purchaseList,
    inventoryContext inventoryContext,
    purchaseRecordContext purchaseRecordContext
  ) {
    foreach (var purchase in purchaseList) {
      purchaseRecordContext.purchase_record.Add(purchase);
      var newInventory = new inventory() {
        inventory_type = purchase.purchase_type,
        inventory_name = purchase.purchase_name,
        purchase_price = purchase.purchase_price,
        inventory_quantity = purchase.purchase_quantity,
        purchase_time = purchase.purchase_time,
        purchase_manufacturer = purchase.purchase_manufacturer
      };
      inventoryContext.inventories.Add(newInventory);
    }
    await inventoryContext.SaveChangesAsync();
    await purchaseRecordContext.SaveChangesAsync();
    return Results.Ok();
  }
}
