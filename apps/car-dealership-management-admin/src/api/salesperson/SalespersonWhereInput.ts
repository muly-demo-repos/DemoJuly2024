import { StringFilter } from "../../util/StringFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { SaleListRelationFilter } from "../sale/SaleListRelationFilter";

export type SalespersonWhereInput = {
  id?: StringFilter;
  name?: StringNullableFilter;
  email?: StringNullableFilter;
  phone?: StringNullableFilter;
  sales?: SaleListRelationFilter;
};
