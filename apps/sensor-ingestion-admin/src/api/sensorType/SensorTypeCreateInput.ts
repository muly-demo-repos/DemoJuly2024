import { SensorCreateNestedManyWithoutSensorTypesInput } from "./SensorCreateNestedManyWithoutSensorTypesInput";

export type SensorTypeCreateInput = {
  sensors?: SensorCreateNestedManyWithoutSensorTypesInput;
  typeName?: string | null;
};
