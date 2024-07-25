import { OrderItemUpdateManyWithoutProductsInput } from "./OrderItemUpdateManyWithoutProductsInput";

export type ProductUpdateInput = {
  stock?: number | null;
  name?: string | null;
  description?: string | null;
  price?: number | null;
  orderItems?: OrderItemUpdateManyWithoutProductsInput;
};
