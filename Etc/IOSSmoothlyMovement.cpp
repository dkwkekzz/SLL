// Fill out your copyright notice in the Description page of Project Settings.


#include "IOSSmoothlyMovement.h"
#include "TestDefault.h"
#include "Components/StaticMeshComponent.h"
#include "Curves/CurveFloat.h"
#include "Kismet/GameplayStatics.h"

// Sets default values
AIOSSmoothlyMovement::AIOSSmoothlyMovement()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	Mesh = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("Mesh"));
	SpeedCurve = CreateDefaultSubobject<UCurveFloat>(TEXT("SpeedCurve"));

	RootComponent = Mesh;
}

// Called when the game starts or when spawned
void AIOSSmoothlyMovement::BeginPlay()
{
	Super::BeginPlay();

	SetDestination(End);
}

// Called every frame
void AIOSSmoothlyMovement::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

	ProcessInput(DeltaTime);
	ProcessTranslate(DeltaTime);
}

void AIOSSmoothlyMovement::ProcessTranslate(float DeltaTime)
{
	auto CurLocation = GetActorLocation();
	auto CurDiff = mTargetLocation - CurLocation;
	auto CurDistanceSquared = CurDiff.SizeSquared();
	if (CurDistanceSquared < 0.001f)
	{
		return;
		//if (mTargetLocation.Equals(Begin, 0.001f))
		//	mTargetLocation = End;
		//else
		//	mTargetLocation = Begin;
	}

	auto CurDir = CurDiff.GetSafeNormal();
	auto DR = 1.f - (CurDistanceSquared / mDistanceFromBeginToEndSquared);
	auto CurSpeed = SpeedCurve->GetFloatValue(DR) * SpeedScale;
	auto AfterLocation = CurLocation + (CurDir * CurSpeed * DeltaTime);
	auto AfterDir = (mTargetLocation - AfterLocation).GetSafeNormal();
	if (FVector::DotProduct(CurDir, AfterDir) < 0.f)
	{
		AfterLocation = mTargetLocation;
	}

	SetActorLocation(AfterLocation);
}

void AIOSSmoothlyMovement::ProcessInput(float DeltaTime)
{
	auto PlayerController = UGameplayStatics::GetPlayerController(GetWorld(), 0);
	if (PlayerController->GetInputAnalogKeyState(EKeys::A))
	{
		FVector2D MousePosition;
		PlayerController->GetMousePosition(MousePosition.X, MousePosition.Y);
		UE_LOG(TestDefault, Warning, TEXT("mouse:(%f, %f)"), MousePosition.X, MousePosition.Y);

		FVector WorldLocation;
		FVector WorldDirection;
		UGameplayStatics::DeprojectScreenToWorld(PlayerController, MousePosition, WorldLocation, WorldDirection);
		UE_LOG(TestDefault, Warning, TEXT("deproject:(%f, %f, %f)"), WorldLocation.X, WorldLocation.Y, WorldLocation.Z);

		SetDestination(WorldLocation);
	}
}

void AIOSSmoothlyMovement::SetDestination(const FVector& InLocation)
{
	mTargetLocation = InLocation;
	mDistanceFromBeginToEndSquared = (mTargetLocation - GetActorLocation()).SizeSquared();
}