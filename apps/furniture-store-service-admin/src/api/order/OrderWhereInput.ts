import { StringFilter } from "../../util/StringFilter";
import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";
import { CustomerWhereUniqueInput } from "../customer/CustomerWhereUniqueInput";
import { OrderItemListRelationFilter } from "../orderItem/OrderItemListRelationFilter";

export type OrderWhereInput = {
  id?: StringFilter;
  date?: DateTimeNullableFilter;
  status?: "Option1";
  customer?: CustomerWhereUniqueInput;
  orderItems?: OrderItemListRelationFilter;
};
