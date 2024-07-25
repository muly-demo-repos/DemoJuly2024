import { StringFilter } from "../../util/StringFilter";
import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";
import { FloatNullableFilter } from "../../util/FloatNullableFilter";
import { CarWhereUniqueInput } from "../car/CarWhereUniqueInput";
import { CustomerWhereUniqueInput } from "../customer/CustomerWhereUniqueInput";
import { SalespersonWhereUniqueInput } from "../salesperson/SalespersonWhereUniqueInput";

export type SaleWhereInput = {
  id?: StringFilter;
  date?: DateTimeNullableFilter;
  totalPrice?: FloatNullableFilter;
  car?: CarWhereUniqueInput;
  customer?: CustomerWhereUniqueInput;
  salesperson?: SalespersonWhereUniqueInput;
};
