import { StringFilter } from "../../util/StringFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { SaleListRelationFilter } from "../sale/SaleListRelationFilter";

export type CustomerWhereInput = {
  id?: StringFilter;
  name?: StringNullableFilter;
  email?: StringNullableFilter;
  phone?: StringNullableFilter;
  address?: StringNullableFilter;
  sales?: SaleListRelationFilter;
};
