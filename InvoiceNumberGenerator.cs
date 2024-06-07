namespace Nlabs.InvoiceNumberGenerator;
public static class PurchaseNumberGenerator
{
    public static string GeneratePurchaseRequestFormNumber(string prefix, string currentMaxNumber)
    {
        string datePart = DateTime.Now.ToString("yyyyMMdd");

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(currentMaxNumber) && currentMaxNumber.StartsWith(prefix + datePart))
        {
            string numberPart = currentMaxNumber.Substring(prefix.Length + datePart.Length);
            nextNumber = int.Parse(numberPart) + 1;
        }

        return $"{prefix}{datePart}{nextNumber:D10}";
    }
}
