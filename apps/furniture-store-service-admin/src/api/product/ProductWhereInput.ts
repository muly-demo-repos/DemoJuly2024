import { StringFilter } from "../../util/StringFilter";
import { IntNullableFilter } from "../../util/IntNullableFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { FloatNullableFilter } from "../../util/FloatNullableFilter";
import { OrderItemListRelationFilter } from "../orderItem/OrderItemListRelationFilter";

export type ProductWhereInput = {
  id?: StringFilter;
  stock?: IntNullableFilter;
  name?: StringNullableFilter;
  description?: StringNullableFilter;
  price?: FloatNullableFilter;
  orderItems?: OrderItemListRelationFilter;
};
