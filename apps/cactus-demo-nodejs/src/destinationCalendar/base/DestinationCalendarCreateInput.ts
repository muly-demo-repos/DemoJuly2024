/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { InputType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import {
  IsString,
  MaxLength,
  ValidateNested,
  IsOptional,
} from "class-validator";
import { UserWhereUniqueInput } from "../../user/base/UserWhereUniqueInput";
import { Type } from "class-transformer";
import { BookingWhereUniqueInput } from "../../booking/base/BookingWhereUniqueInput";
import { EventTypeWhereUniqueInput } from "../../eventType/base/EventTypeWhereUniqueInput";
import { CredentialWhereUniqueInput } from "../../credential/base/CredentialWhereUniqueInput";

@InputType()
class DestinationCalendarCreateInput {
  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @MaxLength(256)
  @Field(() => String)
  integration!: string;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @MaxLength(256)
  @Field(() => String)
  externalId!: string;

  @ApiProperty({
    required: false,
    type: () => UserWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => UserWhereUniqueInput)
  @IsOptional()
  @Field(() => UserWhereUniqueInput, {
    nullable: true,
  })
  user?: UserWhereUniqueInput | null;

  @ApiProperty({
    required: false,
    type: () => BookingWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => BookingWhereUniqueInput)
  @IsOptional()
  @Field(() => BookingWhereUniqueInput, {
    nullable: true,
  })
  booking?: BookingWhereUniqueInput | null;

  @ApiProperty({
    required: false,
    type: () => EventTypeWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => EventTypeWhereUniqueInput)
  @IsOptional()
  @Field(() => EventTypeWhereUniqueInput, {
    nullable: true,
  })
  eventType?: EventTypeWhereUniqueInput | null;

  @ApiProperty({
    required: false,
    type: () => CredentialWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => CredentialWhereUniqueInput)
  @IsOptional()
  @Field(() => CredentialWhereUniqueInput, {
    nullable: true,
  })
  credential?: CredentialWhereUniqueInput | null;
}

export { DestinationCalendarCreateInput as DestinationCalendarCreateInput };
