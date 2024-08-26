import { SensorType as TSensorType } from "../api/sensorType/SensorType";

export const SENSORTYPE_TITLE_FIELD = "typeName";

export const SensorTypeTitle = (record: TSensorType): string => {
  return record.typeName?.toString() || String(record.id);
};
