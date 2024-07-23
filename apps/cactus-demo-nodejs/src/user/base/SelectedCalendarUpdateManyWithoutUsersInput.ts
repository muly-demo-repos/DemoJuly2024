/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { InputType, Field } from "@nestjs/graphql";
import { SelectedCalendarWhereUniqueInput } from "../../selectedCalendar/base/SelectedCalendarWhereUniqueInput";
import { ApiProperty } from "@nestjs/swagger";

@InputType()
class SelectedCalendarUpdateManyWithoutUsersInput {
  @Field(() => [SelectedCalendarWhereUniqueInput], {
    nullable: true,
  })
  @ApiProperty({
    required: false,
    type: () => [SelectedCalendarWhereUniqueInput],
  })
  connect?: Array<SelectedCalendarWhereUniqueInput>;

  @Field(() => [SelectedCalendarWhereUniqueInput], {
    nullable: true,
  })
  @ApiProperty({
    required: false,
    type: () => [SelectedCalendarWhereUniqueInput],
  })
  disconnect?: Array<SelectedCalendarWhereUniqueInput>;

  @Field(() => [SelectedCalendarWhereUniqueInput], {
    nullable: true,
  })
  @ApiProperty({
    required: false,
    type: () => [SelectedCalendarWhereUniqueInput],
  })
  set?: Array<SelectedCalendarWhereUniqueInput>;
}

export { SelectedCalendarUpdateManyWithoutUsersInput as SelectedCalendarUpdateManyWithoutUsersInput };