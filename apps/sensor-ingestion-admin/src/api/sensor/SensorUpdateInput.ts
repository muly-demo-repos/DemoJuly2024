import { SensorReadingUpdateManyWithoutSensorsInput } from "./SensorReadingUpdateManyWithoutSensorsInput";
import { SensorTypeWhereUniqueInput } from "../sensorType/SensorTypeWhereUniqueInput";

export type SensorUpdateInput = {
  description?: string | null;
  name?: string | null;
  sensorReadings?: SensorReadingUpdateManyWithoutSensorsInput;
  sensorType?: SensorTypeWhereUniqueInput | null;
};
