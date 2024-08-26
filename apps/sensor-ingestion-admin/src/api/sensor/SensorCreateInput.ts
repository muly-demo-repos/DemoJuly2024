import { SensorReadingCreateNestedManyWithoutSensorsInput } from "./SensorReadingCreateNestedManyWithoutSensorsInput";
import { SensorTypeWhereUniqueInput } from "../sensorType/SensorTypeWhereUniqueInput";

export type SensorCreateInput = {
  description?: string | null;
  name?: string | null;
  sensorReadings?: SensorReadingCreateNestedManyWithoutSensorsInput;
  sensorType?: SensorTypeWhereUniqueInput | null;
};
