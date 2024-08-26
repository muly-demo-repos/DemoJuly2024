import { SensorReading as TSensorReading } from "../api/sensorReading/SensorReading";

export const SENSORREADING_TITLE_FIELD = "id";

export const SensorReadingTitle = (record: TSensorReading): string => {
  return record.id?.toString() || String(record.id);
};
