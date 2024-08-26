import * as React from "react";

import {
  Edit,
  SimpleForm,
  EditProps,
  ReferenceArrayInput,
  SelectArrayInput,
  TextInput,
} from "react-admin";

import { SensorTitle } from "../sensor/SensorTitle";

export const SensorTypeEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <ReferenceArrayInput
          source="sensors"
          reference="Sensor"
          parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
          format={(value: any) => value && value.map((v: any) => v.id)}
        >
          <SelectArrayInput optionText={SensorTitle} />
        </ReferenceArrayInput>
        <TextInput label="typeName" source="typeName" />
      </SimpleForm>
    </Edit>
  );
};
