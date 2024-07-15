import { StringFilter } from "../../util/StringFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { CarListRelationFilter } from "../car/CarListRelationFilter";

export type CustomerWhereInput = {
  id?: StringFilter;
  name?: StringNullableFilter;
  lastName?: StringNullableFilter;
  cars?: CarListRelationFilter;
};
