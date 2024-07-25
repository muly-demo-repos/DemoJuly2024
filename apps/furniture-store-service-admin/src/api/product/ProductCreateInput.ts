import { OrderItemCreateNestedManyWithoutProductsInput } from "./OrderItemCreateNestedManyWithoutProductsInput";

export type ProductCreateInput = {
  stock?: number | null;
  name?: string | null;
  description?: string | null;
  price?: number | null;
  orderItems?: OrderItemCreateNestedManyWithoutProductsInput;
};
