import { SensorUpdateManyWithoutSensorTypesInput } from "./SensorUpdateManyWithoutSensorTypesInput";

export type SensorTypeUpdateInput = {
  sensors?: SensorUpdateManyWithoutSensorTypesInput;
  typeName?: string | null;
};
