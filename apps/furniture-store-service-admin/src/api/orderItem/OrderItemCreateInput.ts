import { ProductWhereUniqueInput } from "../product/ProductWhereUniqueInput";
import { OrderWhereUniqueInput } from "../order/OrderWhereUniqueInput";

export type OrderItemCreateInput = {
  quantity?: number | null;
  product?: ProductWhereUniqueInput | null;
  order?: OrderWhereUniqueInput | null;
};
