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

export const SalespersonEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput label="lastName" source="lastName" />
        <TextInput label="phone" source="phone" />
        <TextInput label="firstName" source="firstName" />
        <TextInput label="email" source="email" type="email" />
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
