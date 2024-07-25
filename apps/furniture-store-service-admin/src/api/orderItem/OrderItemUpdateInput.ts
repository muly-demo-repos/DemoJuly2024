import { ProductWhereUniqueInput } from "../product/ProductWhereUniqueInput";
import { OrderWhereUniqueInput } from "../order/OrderWhereUniqueInput";

export type OrderItemUpdateInput = {
  quantity?: number | null;
  product?: ProductWhereUniqueInput | null;
  order?: OrderWhereUniqueInput | null;
};
