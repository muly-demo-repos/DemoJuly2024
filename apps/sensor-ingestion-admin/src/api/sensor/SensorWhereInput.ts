import { StringNullableFilter } from "../../util/StringNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { SensorReadingListRelationFilter } from "../sensorReading/SensorReadingListRelationFilter";
import { SensorTypeWhereUniqueInput } from "../sensorType/SensorTypeWhereUniqueInput";

export type SensorWhereInput = {
  description?: StringNullableFilter;
  id?: StringFilter;
  name?: StringNullableFilter;
  sensorReadings?: SensorReadingListRelationFilter;
  sensorType?: SensorTypeWhereUniqueInput;
};
