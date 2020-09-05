// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "IOSSmoothlyMovement.generated.h"

UCLASS()
class TESTDEFAULT_API AIOSSmoothlyMovement : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AIOSSmoothlyMovement();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	UPROPERTY(VisibleAnywhere, Category = My)
	class UStaticMeshComponent* Mesh;
	
	UPROPERTY(EditAnywhere, Category = My)
	FVector Begin;
	
	UPROPERTY(EditAnywhere, Category = My)
	FVector End;
	
	UPROPERTY(EditAnywhere, Category = My)
	float SpeedScale;

	UPROPERTY(EditAnywhere, Category = My)
	class UCurveFloat* SpeedCurve;

private:
	void ProcessTranslate(float DeltaTime);
	void ProcessInput(float DeltaTime);
	void SetDestination(const FVector& InLocation);

	float mDistanceFromBeginToEndSquared;
	FVector mTargetLocation;

};
