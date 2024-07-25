import { StringFilter } from "../../util/StringFilter";
import { IntNullableFilter } from "../../util/IntNullableFilter";
import { ProductWhereUniqueInput } from "../product/ProductWhereUniqueInput";
import { OrderWhereUniqueInput } from "../order/OrderWhereUniqueInput";

export type OrderItemWhereInput = {
  id?: StringFilter;
  quantity?: IntNullableFilter;
  product?: ProductWhereUniqueInput;
  order?: OrderWhereUniqueInput;
};
