import { StringFilter } from "../../util/StringFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { SaleListRelationFilter } from "../sale/SaleListRelationFilter";

export type SalespersonWhereInput = {
  id?: StringFilter;
  lastName?: StringNullableFilter;
  phone?: StringNullableFilter;
  firstName?: StringNullableFilter;
  email?: StringNullableFilter;
  sales?: SaleListRelationFilter;
};
