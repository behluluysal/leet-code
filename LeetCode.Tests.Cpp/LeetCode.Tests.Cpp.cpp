#include "pch.h"
#include "CppUnitTest.h"
#include "ListNode.h"
#include "TreeNode.h"
#include "Questions.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace LeetCodeTestsCpp
{
	TEST_CLASS(LeetCodeTestsCpp)
	{
	public:

		TEST_METHOD(Test_DeleteMiddle_SingleElement)
		{
			ListNode* head = createLinkedList({ 1 });
			ListNode* result = deleteMiddle(head);
			Assert::IsNull(result, L"The result should be null after deleting the middle node in a single-element list.");
			deleteLinkedList(result);
		}

		TEST_METHOD(Test_DeleteMiddle_TwoElementList)
		{
			ListNode* head = createLinkedList({ 1, 2 });
			ListNode* result = deleteMiddle(head);
			std::vector<int> output = linkedListToVector(result);
			std::vector<int> expected = { 1 };
			Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
			for (size_t i = 0; i < output.size(); ++i) {
				Assert::AreEqual(expected[i], output[i], L"Element mismatch");
			}
			deleteLinkedList(result);
		}

		TEST_METHOD(Test_DeleteMiddle_MultipleElementsOdd)
		{
			ListNode* head = createLinkedList({ 1, 2, 3, 4, 5 });
			ListNode* result = deleteMiddle(head);
			std::vector<int> output = linkedListToVector(result);
			std::vector<int> expected = { 1, 2, 4, 5 };
			Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
			for (size_t i = 0; i < output.size(); ++i) {
				Assert::AreEqual(expected[i], output[i], L"Element mismatch");
			}
			deleteLinkedList(result);
		}

		TEST_METHOD(Test_DeleteMiddle_MultipleElementsEven)
		{
			ListNode* head = createLinkedList({ 1, 2, 3, 4 });
			ListNode* result = deleteMiddle(head);
			std::vector<int> output = linkedListToVector(result);
			std::vector<int> expected = { 1, 2, 4 };
			Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
			for (size_t i = 0; i < output.size(); ++i) {
				Assert::AreEqual(expected[i], output[i], L"Element mismatch");
			}
			deleteLinkedList(result);
		}

		TEST_METHOD(Test_OddEvenList_EmptyList)
		{
			ListNode* head = nullptr;
			Assert::IsNull(oddEvenList(head));
		}

		TEST_METHOD(Test_OddEvenList_SingleElement)
		{
			ListNode* head = createLinkedList({ 1 });
			ListNode* result = oddEvenList(head);
			std::vector<int> output = linkedListToVector(result);

			std::vector<int> expected = { 1 };
			Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
			for (size_t i = 0; i < output.size(); ++i) {
				Assert::AreEqual(expected[i], output[i], L"Element mismatch");
			}
			deleteLinkedList(result);
		}

		TEST_METHOD(Test_OddEvenList_MultipleElements)
		{
			ListNode* head = createLinkedList({ 2, 1, 3, 5, 6, 4, 7 });
			ListNode* result = oddEvenList(head);
			std::vector<int> output = linkedListToVector(result);

			std::vector<int> expected = { 2, 3, 6, 7, 1, 5, 4 };
			Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
			for (size_t i = 0; i < output.size(); ++i) {
				Assert::AreEqual(expected[i], output[i], L"Element mismatch");
			}
			deleteLinkedList(result);
		}

		TEST_METHOD(Test_OddEvenList_AlreadySorted)
		{
			ListNode* head = createLinkedList({ 1, 2, 3, 4, 5 });
			ListNode* result = oddEvenList(head);
			std::vector<int> output = linkedListToVector(result);

			std::vector<int> expected = { 1, 3, 5, 2, 4 };
			Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
			for (size_t i = 0; i < output.size(); ++i) {
				Assert::AreEqual(expected[i], output[i], L"Element mismatch");
			}
			deleteLinkedList(result);
		}

		TEST_METHOD(Test_TreeNode_Height)
		{
			TreeNode* head = createBinaryTree({ 3,9,20,-1,-1,15,7 });
			int result = maxDepth(head);
			Assert::AreEqual(3, result, L"Height was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_Height2)
		{
			TreeNode* head = createBinaryTree({ 1, -1, 2 });
			int result = maxDepth(head);
			Assert::AreEqual(2, result, L"Height was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_LeafSimilar)
		{
			TreeNode* head = createBinaryTree({ 3, 5, 1, 6, 2, 9, 8, -1, -1, 7, 4 });
			TreeNode* head2 = createBinaryTree({ 3, 5, 1, 6, 7, 4, 2, -1, -1, -1, -1, -1, -1, 9, 8 });
			bool result = leafSimilar(head, head2);
			Assert::AreEqual(true, result, L"Result was different.");
			deleteBinaryTree(head);
			deleteBinaryTree(head2);
		}

		TEST_METHOD(Test_TreeNode_LeafSimilar2)
		{
			TreeNode* head = createBinaryTree({ 3,5,1,6,7,4,2,-1,-1,-1,-1,-1,-1,9,11,-1,-1,8,10 });
			TreeNode* head2 = createBinaryTree({ 3,5,1,6,2,9,8,-1,-1,7,4 });
			bool result = leafSimilar(head, head2);
			Assert::AreEqual(false, result, L"Result was different.");
			deleteBinaryTree(head);
			deleteBinaryTree(head2);
		}

		TEST_METHOD(Test_TreeNode_GoodNodes)
		{
			TreeNode* head = createBinaryTree({ 3, 1, 4, 3, -1, 1, 5 });
			int result = goodNodes(head);
			Assert::AreEqual(4, result, L"Result was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_GoodNodes2)
		{
			TreeNode* head = createBinaryTree({ 9, -1, 3, 6 });
			int result = goodNodes(head);
			Assert::AreEqual(1, result, L"Result was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_PathSum)
		{
			TreeNode* head = createBinaryTree({ 10,5,-3,3,2,-1,11,3,-2,-1,1 });
			int result = pathSum(head, 8);
			Assert::AreEqual(3, result, L"Result was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_PathSum2)
		{
			TreeNode* head = createBinaryTree({ 5,4,8,11,-1,13,4,7,2,-1,-1,5,1 });
			int result = pathSum(head, 22);
			Assert::AreEqual(3, result, L"Result was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_LongestZigZag)
		{
			TreeNode* head = createBinaryTree({ 1,-1,2,3,4,-1,-1,5,6,-1,7,-1,-1,-1,8 });
			int result = longestZigZag(head);
			Assert::AreEqual(3, result, L"Result was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_LongestZigZag2)
		{
			TreeNode* head = createBinaryTree({ 1, 2, -1, -1, 3 });
			int result = longestZigZag(head);
			Assert::AreEqual(2, result, L"Result was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_LongestZigZag3)
		{
			TreeNode* head = createBinaryTree({ 1 });
			int result = longestZigZag(head);
			Assert::AreEqual(0, result, L"Result was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_Lca1)
		{
			TreeNode* head = createBinaryTree({ 3,5,1,6,2,0,8,-1,-1,7,4 });
			TreeNode* p = findNode(head, 5);
			TreeNode* q = findNode(head, 1);
			TreeNode* result = lowestCommonAncestor(head, p, q);
			Assert::AreEqual(3, result->val, L"Result was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_RightSideView)
		{
			TreeNode* head = createBinaryTree({ 1,2,3,-1,5,-1,4 });
			std::vector<int> result = rightSideView(head);
			std::vector<int> expected = { 1, 3, 4 };
			Assert::IsTrue(result.size() == expected.size(), L"Size mismatch");
			for (size_t i = 0; i < result.size(); ++i) {
				Assert::AreEqual(expected[i], result[i], L"Element mismatch");
			}
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_MaxLevelSum)
		{
			TreeNode* head = createBinaryTree({ 1,7,0,7,-8,-1,-1 });
			int result = maxLevelSum(head);
			Assert::AreEqual(2, result, L"Result was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_MaxLevelSum2)
		{
			TreeNode* head = createBinaryTree({ 989,-1,10250,98693,-89388,-1,-1,-1,-32127 });
			int result = maxLevelSum(head);
			Assert::AreEqual(2, result, L"Result was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_MaxLevelSum3)
		{
			TreeNode* head = createBinaryTree({ -100,-200,-300,-20,-5,-10,-1 });
			int result = maxLevelSum(head);
			Assert::AreEqual(3, result, L"Result was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_SearchBst)
		{
			TreeNode* head = createBinaryTree({ 4,2,7,1,3 });
			TreeNode* result = searchBST(head, 2);
			Assert::AreEqual(2, result->val, L"Result was different.");
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_DeleteNode)
		{
			TreeNode* head = createBinaryTree({ 5,3,6,2,4,-1,7 });
			TreeNode* result = deleteNode(head, 3);
			std::vector<int> expected = { 5, 4, 6, 2, 7 };
			std::vector<int> output = binaryTreeToVector(result);
			output.erase(std::remove(output.begin(), output.end(), -1), output.end());

			Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
			for (size_t i = 0; i < output.size(); ++i) {
				Assert::AreEqual(output[i], expected[i], L"Element mismatch");
			}
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_DeleteNode2)
		{
			TreeNode* head = createBinaryTree({ 0 });
			TreeNode* result = deleteNode(head, 0);
			std::vector<int> expected = {  };
			std::vector<int> output = binaryTreeToVector(result);
			output.erase(std::remove(output.begin(), output.end(), -1), output.end());

			Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
			for (size_t i = 0; i < output.size(); ++i) {
				Assert::AreEqual(output[i], expected[i], L"Element mismatch");
			}
			deleteBinaryTree(head);
		}

		TEST_METHOD(Test_TreeNode_CanVisitAllRooms)
		{
			std::vector<std::vector<int>> rooms = { {1}, {2}, {3}, {} };
			bool expected = true;

			bool result = canVisitAllRooms(rooms);

			Assert::AreEqual(expected, result);
		}

#pragma region [ RoadMap Tests ]

		TEST_METHOD(Test_ListNode_HasCycle)
		{
			ListNode* head = createLinkedList({ 3,2,0,-4 });
			ListNode* temp = head->next->next->next;
			temp->next = head->next;
			bool result = hasCycle(head);
			temp->next = nullptr;
			Assert::AreEqual(true, result);
			deleteLinkedList(head);
		}

		TEST_METHOD(Test_ListNode_ReorderList)
		{
			ListNode* head = createLinkedList({ 1,2,3,4,5 });
			reorderList(head);
			std::vector<int> expected = { 1,5,2,4,3 };

			std::vector<int> output = linkedListToVector(head);
			Assert::IsTrue(output.size() == expected.size(), L"Size mismatch");
			for (size_t i = 0; i < output.size(); ++i) {
				Assert::AreEqual(expected[i], output[i], L"Element mismatch");
			}
			deleteLinkedList(head);
		}

#pragma endregion

	};
}
