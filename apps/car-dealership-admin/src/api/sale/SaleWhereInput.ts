import { StringFilter } from "../../util/StringFilter";
import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";
import { FloatNullableFilter } from "../../util/FloatNullableFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { SalespersonWhereUniqueInput } from "../salesperson/SalespersonWhereUniqueInput";

export type SaleWhereInput = {
  id?: StringFilter;
  date?: DateTimeNullableFilter;
  amount?: FloatNullableFilter;
  client?: StringNullableFilter;
  salesperson?: SalespersonWhereUniqueInput;
  vehicle?: StringNullableFilter;
};
