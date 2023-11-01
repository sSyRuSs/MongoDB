export interface Product{
    productID: string;
    productName: string;
    productImage: string;
    unitPrice: number;
    productQuantity: number;
    Discount: number;
    Category:{
        CatID: string;
        categoryName: string;
    };
    Supplier:{
        SupID: string;
        supplierName: string;
    };
}