import * as React from "react";

import {
  Edit,
  SimpleForm,
  EditProps,
  TextInput,
  ReferenceArrayInput,
  SelectArrayInput,
} from "react-admin";

import { SaleTitle } from "../sale/SaleTitle";

export const CustomerEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput label="name" source="name" />
        <TextInput label="email" source="email" type="email" />
        <TextInput label="phone" source="phone" />
        <TextInput label="address" source="address" />
        <ReferenceArrayInput
          source="sales"
          reference="Sale"
          parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
          format={(value: any) => value && value.map((v: any) => v.id)}
        >
          <SelectArrayInput optionText={SaleTitle} />
        </ReferenceArrayInput>
      </SimpleForm>
    </Edit>
  );
};
