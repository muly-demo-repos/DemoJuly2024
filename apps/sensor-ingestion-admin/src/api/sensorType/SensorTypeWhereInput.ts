import { StringFilter } from "../../util/StringFilter";
import { SensorListRelationFilter } from "../sensor/SensorListRelationFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";

export type SensorTypeWhereInput = {
  id?: StringFilter;
  sensors?: SensorListRelationFilter;
  typeName?: StringNullableFilter;
};
