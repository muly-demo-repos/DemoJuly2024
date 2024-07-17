/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { ObjectType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import {
  IsString,
  MaxLength,
  IsOptional,
  IsDate,
  IsBoolean,
  IsEnum,
  ValidateNested,
} from "class-validator";
import { Type } from "class-transformer";
import { EnumWebhookEventTriggers } from "./EnumWebhookEventTriggers";
import { User } from "../../user/base/User";
import { EventType } from "../../eventType/base/EventType";
import { AppModel } from "../../appModel/base/AppModel";

@ObjectType()
class Webhook {
  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @Field(() => String)
  id!: string;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @MaxLength(256)
  @Field(() => String)
  subscriberUrl!: string;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @MaxLength(256)
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  payloadTemplate!: string | null;

  @ApiProperty({
    required: true,
  })
  @IsDate()
  @Type(() => Date)
  @Field(() => Date)
  createdAt!: Date;

  @ApiProperty({
    required: true,
    type: Boolean,
  })
  @IsBoolean()
  @Field(() => Boolean)
  active!: boolean;

  @ApiProperty({
    required: true,
    enum: EnumWebhookEventTriggers,
    isArray: true,
  })
  @IsEnum(EnumWebhookEventTriggers, {
    each: true,
  })
  @IsOptional()
  @Field(() => [EnumWebhookEventTriggers], {
    nullable: true,
  })
  eventTriggers?: Array<
    "BOOKING_CREATED" | "BOOKING_RESCHEDULED" | "BOOKING_CANCELLED"
  >;

  @ApiProperty({
    required: false,
    type: () => User,
  })
  @ValidateNested()
  @Type(() => User)
  @IsOptional()
  user?: User | null;

  @ApiProperty({
    required: false,
    type: () => EventType,
  })
  @ValidateNested()
  @Type(() => EventType)
  @IsOptional()
  eventType?: EventType | null;

  @ApiProperty({
    required: false,
    type: () => AppModel,
  })
  @ValidateNested()
  @Type(() => AppModel)
  @IsOptional()
  appField?: AppModel | null;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @MaxLength(256)
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  secret!: string | null;
}

export { Webhook as Webhook };
