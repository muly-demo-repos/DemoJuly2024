import { StringFilter } from "../../util/StringFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { IntNullableFilter } from "../../util/IntNullableFilter";
import { SaleListRelationFilter } from "../sale/SaleListRelationFilter";
import { FloatNullableFilter } from "../../util/FloatNullableFilter";

export type CarWhereInput = {
  id?: StringFilter;
  make?: StringNullableFilter;
  year?: IntNullableFilter;
  model?: StringFilter;
  sales?: SaleListRelationFilter;
  price?: FloatNullableFilter;
  licenseNumber?: StringNullableFilter;
};
