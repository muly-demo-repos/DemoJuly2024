import * as React from "react";

import {
  Edit,
  SimpleForm,
  EditProps,
  TextInput,
  ReferenceArrayInput,
  SelectArrayInput,
  ReferenceInput,
  SelectInput,
} from "react-admin";

import { SensorReadingTitle } from "../sensorReading/SensorReadingTitle";
import { SensorTypeTitle } from "../sensorType/SensorTypeTitle";

export const SensorEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput label="description" multiline source="description" />
        <TextInput label="name" source="name" />
        <ReferenceArrayInput
          source="sensorReadings"
          reference="SensorReading"
          parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
          format={(value: any) => value && value.map((v: any) => v.id)}
        >
          <SelectArrayInput optionText={SensorReadingTitle} />
        </ReferenceArrayInput>
        <ReferenceInput
          source="sensorType.id"
          reference="SensorType"
          label="sensorType"
        >
          <SelectInput optionText={SensorTypeTitle} />
        </ReferenceInput>
      </SimpleForm>
    </Edit>
  );
};
