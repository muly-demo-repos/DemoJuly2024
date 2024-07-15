import { StringFilter } from "../../util/StringFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { DecimalNullableFilter } from "../../util/DecimalNullableFilter";
import { CustomerWhereUniqueInput } from "../customer/CustomerWhereUniqueInput";

export type CarWhereInput = {
  id?: StringFilter;
  licenseNumber?: StringNullableFilter;
  mileage?: DecimalNullableFilter;
  customer?: CustomerWhereUniqueInput;
};
