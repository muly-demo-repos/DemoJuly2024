import * as React from "react";
import { Edit, SimpleForm, EditProps, TextInput } from "react-admin";

export const MulyEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput label="aaa" source="aaa" />
        <TextInput label="abc" source="abc" />
        <TextInput label="beck" source="beck" />
        <TextInput label="fox" source="fox" />
        <TextInput label="niver" source="niver" />
        <TextInput label="park" source="park" />
        <TextInput label="zisIsFirst" source="zisIsFirst" />
      </SimpleForm>
    </Edit>
  );
};
