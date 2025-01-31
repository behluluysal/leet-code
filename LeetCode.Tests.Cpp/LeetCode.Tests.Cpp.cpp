#include "pch.h"
#include "CppUnitTest.h"
#include "ListNode.h"
#include "TreeNode.h"

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
	};
}
